using Flowforge.Models;
using Flowforge.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowforge.NUnit.Repositories;

[TestFixture]
public class IBlockConnectionRepositoryTests
{
    private Mock<IBlockConnectionRepository> _repoMock;

    [SetUp]
    public void Setup()
    {
        _repoMock = new Mock<IBlockConnectionRepository>();
    }

    [Test]
    public async Task GetAllAsync_ReturnsConnections()
    {
        var connections = new List<BlockConnection> { new BlockConnection { Id = 1, SourceBlockId = 1, TargetBlockId = 2 } };
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(connections);

        var result = await _repoMock.Object.GetAllAsync();

        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(1));
        _repoMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task GetByIdAsync_ReturnsConnection_WhenExists()
    {
        var connection = new BlockConnection { Id = 1, SourceBlockId = 1, TargetBlockId = 2 };
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(connection);

        var result = await _repoMock.Object.GetByIdAsync(1);

        Assert.That(result, Is.EqualTo(connection));
        _repoMock.Verify(r => r.GetByIdAsync(1), Times.Once);
    }

    [Test]
    public async Task GetByIdAsync_ReturnsNull_WhenNotExists()
    {
        _repoMock.Setup(r => r.GetByIdAsync(2)).ReturnsAsync((BlockConnection?)null);

        var result = await _repoMock.Object.GetByIdAsync(2);

        Assert.That(result, Is.Null);
        _repoMock.Verify(r => r.GetByIdAsync(2), Times.Once);
    }

    [Test]
    public async Task AddAsync_ReturnsConnection()
    {
        var connection = new BlockConnection { Id = 1, SourceBlockId = 1, TargetBlockId = 2 };
        _repoMock.Setup(r => r.AddAsync(connection)).ReturnsAsync(connection);

        var result = await _repoMock.Object.AddAsync(connection);

        Assert.That(result, Is.EqualTo(connection));
        _repoMock.Verify(r => r.AddAsync(connection), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_ReturnsTrue_WhenSuccess()
    {
        var connection = new BlockConnection { Id = 1, SourceBlockId = 1, TargetBlockId = 2 };
        _repoMock.Setup(r => r.UpdateAsync(connection)).ReturnsAsync(true);

        var result = await _repoMock.Object.UpdateAsync(connection);

        Assert.That(result, Is.True);
        _repoMock.Verify(r => r.UpdateAsync(connection), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_ReturnsFalse_WhenFail()
    {
        var connection = new BlockConnection { Id = 2, SourceBlockId = 1, TargetBlockId = 2 };
        _repoMock.Setup(r => r.UpdateAsync(connection)).ReturnsAsync(false);

        var result = await _repoMock.Object.UpdateAsync(connection);

        Assert.That(result, Is.False);
        _repoMock.Verify(r => r.UpdateAsync(connection), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_ReturnsTrue_WhenSuccess()
    {
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _repoMock.Object.DeleteAsync(1);

        Assert.That(result, Is.True);
        _repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_ReturnsFalse_WhenFail()
    {
        _repoMock.Setup(r => r.DeleteAsync(2)).ReturnsAsync(false);

        var result = await _repoMock.Object.DeleteAsync(2);

        Assert.That(result, Is.False);
        _repoMock.Verify(r => r.DeleteAsync(2), Times.Once);
    }
}